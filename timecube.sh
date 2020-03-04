#!/bin/sh
NXP_NFC_CMD="sudo python3 /home/pi/Desktop/timecube-raspi-modif/timecube.py"

# DEMARRAGE TIMECUBE ------------------------------
start()
{
# test si pas deja en cours
timecube=$(pidof $NXP_NFC_CMD)
if [ -n "$timecube" ]
	then
	echo "Application $NXP_NFC_CMD deja en cours"
	echo "PID : "$timecube
else
	echo "Demarrage - Application $NXP_NFC_CMD"
	$NXP_NFC_CMD > /dev/null 2>&1 &
	echo "Timecube démarré!"
fi
}
# ARRET TIMECUBE ----------------------------------
stop()
{
echo "arret des processus"
# test si pas deja en cours
timecube=$(pidof $NXP_NFC_CMD)
if [ -n "$timecube" ]
	then
	sudo kill $timecube
	echo "Jim est mort!"
else
	echo "Personne à tuer!"
fi
}
#-----------------------------------------------
install()
{
echo "Suppression de l'ancienne config."
sudo rm -r /home/pi/Desktop/timecube-raspi-modif/timelab.mlab.ch/
echo "demarrage du telechargement"
sudo wget -r http://timelab.magneticlab.ch/nfc/timecube.cfg -P /home/pi/Desktop/timecube-raspi-modif/
echo "fichier timecube.cfg recu"
}
#-----------------------------------------------
status()
{
timecube=$(pidof $NXP_NFC_CMD)
if [ -n "$timecube" ]
	then
	echo "Timecube ("$timecube") en cours!"
else
	echo "Timecube arrêté!"
fi
}


#-----------------------------------------------
case "$1" in
start)
start
;;
install)
install
;;
stop)
stop
;;
restart)
stop
start
;;
status)
status
;;
*)
echo $"Usage: $0 {start|stop|restart|install|status}"
exit 3
esac

