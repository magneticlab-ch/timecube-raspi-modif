#!/usr/bin/python
# coding: utf8
# --------------------------------------------
# Description : Lecteur de carte Mifare avec un fichier d'actions
# Auteur : Magneticlab SARL | sp4tz/g0rg/Alex
# Date : 14.04.2016 (Modifié le 13/11/2019)
# Version : 1.3
# --------------------------------------------
from google_speech import Speech
import MFRC522
import signal
import time
import requests, urllib
from urllib.error import URLError
import json
import csv
import sys
import RPi.GPIO as GPIO
from datetime import datetime
from sys import exit
from time import sleep
from subprocess import call
import os
import subprocess
import webbrowser

# NFC
continue_reading = True


def end_read(signal, frame):
    global continue_reading
    continue_reading = False
    print("Lecture terminée")
    GPIO.cleanup()


# Vérification du réseau
def check_network():
    try:
        response = urllib.request.urlopen('https://timelab.magneticlab.ch/nfc/', timeout=1)
        return True
    except urllib.error.URLError as err:
        # print err
        return False
    return False


# Fonction ecrirelog --------------------------
def ecrireLog(texte, speech=False):
    log = open("timecube.log", "a")
    log.write(str(texte) + "\n")
    print(texte)
    log.close()
    if speech:
        lang = "fr"
        speech = Speech(texte, lang)
        sox_effects = ("gain", "1")
        speech.play(sox_effects)


# Fonction populate_sync --------------------------
def populate_sync(sync):
    sy = open("timecube_sync.json", "a")
    sy.write(sync)
    print(sync)
    sy.close()


# Action de pointage ----------------------------
def sync():
    json_file = "timecube_sync.json"
    if os.stat(json_file).st_size > 0:
        if check_network() == True:
            mac = getMAC('eth0') + ':' + getMAC('wlan0')
            json_data = open(json_file).read()
            sync = {}
            sync['data'] = '[' + json_data + ']'
            sync['process'] = 'sync'
            sync['type'] = 'NFC'
            sync['TIMEID'] = mac
            send = {'sync': sync}
            r = requests.post("https://timelab.magneticlab.ch/nfc/rpc.php", data=sync)
            print(r.content)
            data = json.loads(r.text)
            if data['status'] == 'proceed':
                open(json_file, 'w').close()
                ecrireLog(time.strftime("%d.%m.%Y | %H:%M:%S") + " | Fichier synchronisé avec succès.")
                ecrireLog("Fichier synchronisé avec succès.", True)
            time.sleep(3)


# Récupération des adresse MAC eth0 et wlan0
def getMAC(interface):
    try:
        str = open('/sys/class/net/' + interface + '/address').read()
    except:
        str = "00:00:00:00:00:00"
    return str[0:17]


# Fonction actionhttp --------------------------
def actionhttp(user_id, user):
    mac = getMAC('eth0') + ':' + getMAC('wlan0')
    if check_network() == True:
        post_data = {"process": "punch", "ID": user_id, "TIMEID": mac, "type": "NFC"}
        httpget = requests.post("https://timelab.magneticlab.ch/nfc/rpc.php", data=post_data)
        # print(httpget.text)
        try:
            data = json.loads(httpget.text)
        except:
            data = {}
            data['status'] = 'error'
            data['message'] = httpget.text
            print("Erreur: " + httpget.text)
            pass
        if data['status'] == "success":
            ecrireLog('                                     ')
            ecrireLog('#####################################')
            ecrireLog('#####################################')
            ecrireLog('     ' + data['message'] + ' ' + user + '      ')
            ecrireLog('#####################################')
            ecrireLog('#####################################')
            ecrireLog('                                     ')
            # ecrireLog(time.strftime(("%d.%m.%Y | %H:%M:%S") + " | " + user + ' ' + data['message']))
            ecrireLog(data['message'], True)
            write2GUI('3;' + '1;' + user + ";" + data['message'])
            return True
        else:
            ecrireLog(time.strftime(("%d.%m.%Y | %H:%M:%S") + " | " + user + ' ' + data['message']))
            ecrireLog(data['message'] + ' ' + user, True)
    else:
        populate_sync('{"ID": "' + user_id + '", "datetime": "' + time.strftime(
            "%Y-%m-%d %H:%M:%S") + '","TIMEID": "' + mac + '"},')
        ecrireLog("Pas de connexion Internet! Pointage sauvegardé", True)
        time.sleep(2)
        return True


# Conversion de l'UID du badge en hex -----------
def list2HexStr(inData):
    i = 0
    outStr = ""
    while i < len(inData):
        outStr = outStr + '{:02X}'.format(inData[i])
        i = i + 1
    return outStr


# Vérification de l'UID du badge ----------------
def checkUID(uid, punch=True):
    ecrireLog("CHECK UID " + uid)
    # Ouverture du fichier de la liste des badges
    ecrireLog(time.strftime("%d.%m.%Y | %H:%M:%S") + " | Chargement du fichier des badges...")
    fichier = open('/home/pi/Desktop/timecube-raspi-modif/timelab.magneticlab.ch/nfc/timecube.cfg', 'rt')
    reader = csv.reader(fichier, delimiter=';')
    for row in reader:
        if row[0] == uid:
            ecrireLog("UID " + uid + " reconnu, connexion TIMECUBE")
            if punch:
                if (actionhttp(row[1], row[2])):
                    return True
            else:
                return row[1]


signal.signal(signal.SIGINT, end_read)
MIFAREReader = MFRC522.MFRC522()


# Permet de communiquer avec TimeCube GUI
def write2GUI(statut):
    if statut != '':
        timbrage = open("/home/pi/Desktop/timecube-raspi-modif/timbrage.txt", "w+")
        timbrage = open("/home/pi/Desktop/timecube-raspi-modif/user_info_data.json", "w+")
        timbrage.write(statut)
        timbrage.close()


# Virification si GUI demande un accès utilisateur
def checkUserInfoRequest():
    request = open("/home/pi/Desktop/timecube-raspi-modif/user_info.txt").read()
    if request == '1':
        requestUserInfo()
        return True
    else:
        return False


# Rapatriement des infos utilisateur
def requestUserInfo():
    # ecrireLog("USER INFO")
    sleep(1)
    (status, TagType) = MIFAREReader.MFRC522_Request(MIFAREReader.PICC_REQIDL)
    if status == MIFAREReader.MI_OK:
        (status, uid) = MIFAREReader.MFRC522_Anticoll()
        ecrireLog("CARD READ")
        badgeID = list2HexStr(uid)
        ecrireLog("BADGE ID = " + badgeID)
        user_id = checkUID(badgeID, False)
        ecrireLog("USER ID = " + badgeID)
        if user_id:
            mac = getMAC('eth0') + ':' + getMAC('wlan0')
            if check_network() == True:
                post_data = {"process": "userInfo", "ID": user_id, "TIMEID": mac, "type": "NFC"}
                httpget = requests.post("https://timelab.magneticlab.ch/nfc/rpc.php", data=post_data)
                print(httpget.text)
                try:
                    data = json.loads(httpget.text)
                except:
                    write2GUI('error')

                if data['status'] == "success":
                    write2GUI(httpget.text)
                    return True
                else:
                    write2GUI('pipi')
                    return True
            time.sleep(3)
            return True
        else:
            return False
    else:
        return False


def requestPointage():
    (status, uid) = MIFAREReader.MFRC522_Anticoll()
    badgeID = list2HexStr(uid)
    ecrireLog("Carte détéctée")
    ecrireLog("Vérification UID " + str(badgeID))
    if checkUID(badgeID):
        time.sleep(1)
    else:
        write2GUI('3;0')
        ecrireLog("UID " + str(badgeID) + " inconnu!!!", True)
    time.sleep(2)


# Lecture du EXPLORENFC -------------------------
def runReader():
    ecrireLog(time.strftime("%d.%m.%Y | %H:%M:%S") + " | Attente d'un badge TIMECUBE.")
    while continue_reading:
        sync()
        if not checkUserInfoRequest():
            (status, TagType) = MIFAREReader.MFRC522_Request(MIFAREReader.PICC_REQIDL)
            if status == MIFAREReader.MI_OK:
                requestPointage()


# Début du script TIMECUBE
try:
    ecrireLog(time.strftime("%d.%m.%Y | %H:%M:%S") + " | Initialisation TIMECUBE")
    # ecrireLog("Initialisation TIMECUBE", True)
    runReader()
except (SystemExit, KeyboardInterrupt):

    raise
except OSError as err:
    print("OS error: {0}".format(err))
except:
    ecrireLog(time.strftime("%d.%m.%Y | %H:%M:%S") + " | Arret impromptu du script")
    print("Unexpected error:", sys.exc_info()[0])
    # call(['sh timecube.sh restart'], shell=True)
    raise
