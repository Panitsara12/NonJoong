import machine, onewire, ds18x20, time
from machine import I2C
from lcd_api import LcdApi
from pico_i2c_lcd import I2cLcd

def temp():
    ds_pin = machine.Pin(16)
    ds_sensor = ds18x20.DS18X20(onewire.OneWire(ds_pin))
 
    roms = ds_sensor.scan()
    print('Found a ds18x20 device')
 
    while True:
      ds_sensor.convert_temp()
      time.sleep_ms(300)
      
      for rom in roms:
          show = ds_sensor.read_temp(rom)
          float(show)
          if(show>27):
              monitor(show)
          else:
              monitor(show)
          time.sleep(2)
      


def monitor(show):
    showmoni = str(show)
    
    I2C_ADDR     = 0x27
    I2C_NUM_ROWS = 2
    I2C_NUM_COLS = 16

    i2c = I2C(0, sda=machine.Pin(0), scl=machine.Pin(1), freq=400000)
    lcd = I2cLcd(i2c, I2C_ADDR, I2C_NUM_ROWS, I2C_NUM_COLS)

    lcd.putstr(showmoni)

temp()