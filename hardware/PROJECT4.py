from machine import UART, Pin

import time
from machine import I2C, Pin, SPI
from mfrc522 import MFRC522


import machine
import _thread
import time
from machine import I2C
from lcd_api import LcdApi
from pico_i2c_lcd import I2cLcd
import machine, onewire, ds18x20, time
from machine import Pin
import utime
from machine import Pin
import time
import utime
from utime import sleep

from machine import Pin, PWM
from utime import sleep
trigger = Pin(14, Pin.OUT)
echo = Pin(15, Pin.IN)
led = Pin(5, Pin.OUT)
red_led = Pin(0, Pin.OUT)
green_led = Pin(1, Pin.OUT)
def ESP8266Read():
    data=uart.readline()
    if data is not None:
        print(data.decode('UTF8'))
    time.sleep(0.1)
    
uart = UART(0,baudrate=115200, tx=Pin(16), rx=Pin(17))
time.sleep(1.0)
uart.write('SETWIFI,"TOP","0872227388"')
time.sleep(1.0)
#uart.write('SUB,"/ESP/LED1"')
#time.sleep(1.0)
#uart.write('PUB,"/ESP/LED2"')
#time.sleep(1.0)
#_thread.start_new_thread(ESP8266Read(), ()) # starts the webserver in a _thread

led = Pin(25, Pin.OUT)
true = Pin(15, Pin.OUT)
false = Pin(14, Pin.OUT)
sck = Pin(6, Pin.OUT)
mosi = Pin(7, Pin.OUT)
miso = Pin(4, Pin.OUT)
sda = Pin(5, Pin.OUT)
rst = Pin(22, Pin.OUT)
spi = SPI(0, baudrate=100000, polarity=0, phase=0, sck=sck, mosi=mosi, miso=miso)
card1 = "0xeb29f82d"
card2 = "0x12ac531b"


buzzer = PWM(Pin(11))
red_led = Pin(10, Pin.OUT)
green_led = Pin(9, Pin.OUT)

tones = {
"D6": 1175,
}

song = ["D6","D6"]

ds_pin = machine.Pin(13)
ds_sensor = ds18x20.DS18X20(onewire.OneWire(ds_pin))

roms = ds_sensor.scan()
print('Found a ds18x20 device')

ds_sensor.convert_temp()
time.sleep_ms(300)

def monitor(show):
    show = str(show)
    showmoni = "    "+ show
    
    I2C_ADDR     = 0x27
    I2C_NUM_ROWS = 2
    I2C_NUM_COLS = 16

    i2c = I2C(0, sda=machine.Pin(0), scl=machine.Pin(1), freq=400000)
    lcd = I2cLcd(i2c, I2C_ADDR, I2C_NUM_ROWS, I2C_NUM_COLS)

    lcd.putstr(showmoni)

def card_scan():
    rdr = MFRC522(spi, sda, rst)
    (stat, tag_type) = rdr.request(rdr.REQIDL)
    if stat == rdr.OK:
        (stat, raw_uid) = rdr.anticoll()
        if stat == rdr.OK:
            uid = ("0x%02x%02x%02x%02x" % (raw_uid[0], raw_uid[1], raw_uid[2], raw_uid[3]))
            print(uid)
            if uid == card1:
                true.toggle()
                time.sleep(1)
                playsong(song)
                print("card 1 ok ")
                
                
            elif uid == card2:
                true.toggle()
                time.sleep(1)
                print("card 2 ok")
                playsong(song)
           
            else:
                false.value(1)
                time.sleep(0.1)
                false.value(0)
                time.sleep(0.1)
                false.value(1)
                time.sleep(0.1)
                false.value(0)
                time.sleep(0.1)
                false.value(1)
                time.sleep(0.1)
                false.value(0)
                time.sleep(1)
                



def temp_test():
    ds_sensor.convert_temp()
    time.sleep_ms(300)
    
    for rom in roms:
          show = ds_sensor.read_temp(rom)
          #print(ds_sensor.read_temp(rom))
          float(show)
          if(show>25):
              monitor(show)
              show = str(show)
              gg = 'PUB,"NonJoong/hardware/temp",' + '"' + show + '"'
              #print(gg)
              uart.write(gg)
          else:
              monitor(show)
              
def pump_on():
    red_led.value(0)
    green_led.value(1)
    pump1.value(1)
    time.sleep(2)
    
def pump_off():
    red_led.value(1)
    green_led.value(0)
    pump1.value(0)
    
def pump_on2():
    red_led.value(0)
    green_led.value(1)
    pump2.value(1)
    time.sleep(2)
    
    
def pump_off2():
    red_led.value(1)
    green_led.value(0)
    pump2.value(0)
    
    
def pump33():
    if PP33.value()==1:
        if gg == 0:
            print("p2 active")
            red_led.value(0)
            green_led.value(1)
            pump_off()
            
            
            pump_on2()
            gg = 1 
        
        if(gg == 2):
            pump_off2()
            pump_off()
            print("gg p2 and p1 off")
            gg = 3
     
               
    if PP33.value()==0 :
        
        if(gg == 1):
            print("p1 active")
            red_led.value(0)
            green_led.value(1)
            pump_on()
            gg = 2
            sleep(1)
        if gg == 3:
            pump_off2()
            pump_off()
            print("p2 and p1 off no active")
    
def playtone(frequency):
    buzzer.duty_u16(100000)
    buzzer.freq(frequency)

def bequiet():
    buzzer.duty_u16(0)

def playsong(mysong):
    for i in range(len(mysong)):
        if (mysong[i] == "P"):
            bequiet()
            red_led.low()
            green_led.high()
            time.sleep(2)
        else:
            playtone(tones[mysong[i]])
            red_led.high()
            green_led.low()
        sleep(0.3)
    bequiet()

def test():    
    uart.write('SUB,"NonJoong/hardware/temp"')
    time.sleep(1)
while True:
    card_scan()
    time.sleep(1)
    temp_test()
    time.sleep(5)
    test()
    print(uart.read())
    c = uart.read()
    time.sleep(0.1)
    gg = b'STATUS,"OK"\r\nMESSAGE,"NonJoong/hardware/temp","29.25"\r\nMESSAGE,"NonJoong/hardware/temp","ON1"\r\n'
    EZ = "ON1"
    if gg == c:
        green_led.value(1)
        red_led.value(0)
        pump33()
        print('pum no')
        time.sleep(3)

    else :
        #uart.write('PUB,"/ESP/LED1","EMPTY"')
        time.sleep(1.0)


    #elif test == ('MESSAGE,"/ESP/LED1","top"\r\n') :
    #    uart.readline()
     #   time.sleep(1.0)
      #  print(uart.readline())
       # uart.write('PUB,"/ESP/LED1","stop"')
       # time.sleep(2.0)
       # print("STOP")
            
    #else :
        
     #   time.sleep(2.0)
    
    #uart.write('PUB,"/ESP/LED1","distance"')
    #time.sleep(5.0)
