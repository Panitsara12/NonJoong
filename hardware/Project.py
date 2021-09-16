from utime import sleep
import machine, onewire, ds18x20, time
from machine import Pin
from machine import I2C
from lcd_api import LcdApi
from pico_i2c_lcd import I2cLcd
import time
from machine import I2C, Pin, SPI
from mfrc522 import MFRC522
from machine import UART,Pin
import _thread
import time

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
card3 = ""
card4 = ""
card5 = ""
card6 = ""

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
                uart.write('PUB,"22/06/44","GG"')
                print("card 1 ok ")
            elif uid == card2:
                true.toggle()
                time.sleep(1)
                print("card 2 ok")
           
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

def ESP8266Read():
        data=uart.readline()
        if data is not None:
            print(data.decode('UTF8'))
        time.sleep(0.1)
    
uart = UART(0,baudrate=115200, tx=Pin(16), rx=Pin(17))
time.sleep(1.0)
uart.write('SETWIFI,"Pimrada R109","0903319646"')
time.sleep(1.0)

def temp():
    ds_pin = machine.Pin(16)
    ds_sensor = ds18x20.DS18X20(onewire.OneWire(ds_pin))
 
    roms = ds_sensor.scan()
    print('Found a ds18x20 device')
 
    ds_sensor.convert_temp()
    time.sleep_ms(300)
    
      
    for rom in roms:
        show = ds_sensor.read_temp(rom)
          
        monitor(show)
        sleep(3)
        

def monitor(show):
    show = str(show)
    showmoni = "    "+ show
    
    I2C_ADDR     = 0x27
    I2C_NUM_ROWS = 2
    I2C_NUM_COLS = 16

    i2c = I2C(0, sda=machine.Pin(0), scl=machine.Pin(1), freq=400000)
    lcd = I2cLcd(i2c, I2C_ADDR, I2C_NUM_ROWS, I2C_NUM_COLS)

    lcd.putstr(showmoni)



while True:
    card_scan()
    time.sleep(2)
    print(uart.read())
    time.sleep(2)
    gg = b'MESSAGE,"7/2/333","ON"\r\n'
    sleep(1)
    print(uart.read())
    time.sleep(3)
    temp() 
    
    
    
    
    
    
    
    
            
