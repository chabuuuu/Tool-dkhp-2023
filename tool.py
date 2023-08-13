from selenium import webdriver
from selenium.webdriver.common.by import By
import time
from selenium.webdriver.support.wait import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.keys import Keys
from datetime import datetime
import json

with open('setting.json', 'r') as f:
  data = json.load(f)

username = data["username"]
password = data["password"]
danhSachDangKy = data["malop"]

options = webdriver.ChromeOptions()

options.add_experimental_option("detach", True)

driver = webdriver.Chrome(options=options)
driver.get('https://dkhp.uit.edu.vn/app/login')
time.sleep(3)

driver.find_element(By.XPATH, '/html/body/div[1]/div/div/div[2]/div[2]/div/form/div/div[1]/div/input').send_keys(username)
driver.find_element(By.XPATH, '/html/body/div[1]/div/div/div[2]/div[2]/div/form/div/div[2]/div/input').send_keys(password)
driver.find_element(By.XPATH,'/html/body/div[1]/div/div/div[2]/div[2]/div/form/div/div[3]/button').click()
time.sleep(3)
driver.get('https://dkhp.uit.edu.vn/app/courses-registration')
time.sleep(2)
maLop = driver.find_element(By.XPATH,'/html/body/div[1]/div/div[3]/div/div/div[1]/div/div/form/div/table/tbody')
listMaLop = maLop.find_elements(By.TAG_NAME,'tr')
time.sleep(1)
for ml in listMaLop:
    temp = ml.find_elements(By.TAG_NAME,'td')
    malop = temp[1].text
    if malop in danhSachDangKy:
        checkBox = temp[0].find_element(By.TAG_NAME,'input')
        # Lấy kích thước của cửa sổ trình duyệt
        window_height = driver.execute_script("return window.innerHeight;")
        element_y = ml.location["y"]
        element_height = ml.size["height"]

        # Tính toán vị trí cuộn
        scroll_y = element_y - (window_height / 2) + (element_height / 2)

        # Sử dụng execute_script để cuộn đến vị trí tính toán
        driver.execute_script(f"window.scrollTo(0, {scroll_y});")
        
        # driver.execute_script("arguments[0].scrollIntoView();", ml)
        checkBox.click()
        time.sleep(0.5)
    

