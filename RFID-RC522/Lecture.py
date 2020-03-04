#!/usr/bin/env python
# -*- coding: utf8 -*-
# Version modifiee de la librairie https://github.com/mxgxw/MFRC522-python

import RPi.GPIO as GPIO
import MFRC522
import signal

continue_reading = True

# Fonction qui arrete la lecture proprement 
def end_read(signal,frame):
    global continue_reading
    print ("Lecture terminée")
    continue_reading = False
    GPIO.cleanup()


def list2HexStr(inData):
    i = 0
    outStr = ""
    while i<len(inData):
      outStr = outStr+'{:02X}'.format(inData[i])
      i = i+1
    return outStr

	
signal.signal(signal.SIGINT, end_read)
MIFAREReader = MFRC522.MFRC522()

print ("Passer le tag RFID a lire")

while continue_reading:
    
    # Detecter les tags
    (status,TagType) = MIFAREReader.MFRC522_Request(MIFAREReader.PICC_REQIDL)

    # Une carte est detectee
    if status == MIFAREReader.MI_OK:
        print ("Carte detectee")
    
    # Recuperation UID
    (status,uid) = MIFAREReader.MFRC522_Anticoll()
    if status == MIFAREReader.MI_OK:
        print ("UID de la carte : "+str(uid[0])+"."+str(uid[1])+"."+str(uid[2])+"."+str(uid[3]))
	# Affichage des id avec modification pour être identique avec le système de injes
	hexstring = str(list2HexStr(uid))
	hex = list2HexStr(uid)
	hexstring_reversed = str("".join(reversed([hex[i:i+2] for i in range(0, len(hex), 2)])))
	decnumber_timecube = int(hexstring_reversed[2:len(hexstring_reversed)], 16)
	print ("ID Hexa : "+ hexstring[0:len(hexstring)-2])
	print ("ID Hexa reversed : "+ hexstring_reversed[2:len(hexstring_reversed)])
	print ("ID Decimale : "+ str(decnumber_timecube))
    
        # Clee d authentification par defaut
        key = [0xFF,0xFF,0xFF,0xFF,0xFF,0xFF]
        
        # Selection du tag
        MIFAREReader.MFRC522_SelectTag(uid)

        # Authentification
        status = MIFAREReader.MFRC522_Auth(MIFAREReader.PICC_AUTHENT1A, 8, key, uid)

        if status == MIFAREReader.MI_OK:
            MIFAREReader.MFRC522_Read(8)
            MIFAREReader.MFRC522_StopCrypto1()
        else:
            print ("Erreur d\'Authentification")
