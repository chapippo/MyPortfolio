import json

import pymysql
import urllib.request

url = 'http://apis.data.go.kr/1352000/ODMS_COVID_05/callCovid05Api?serviceKey=xgPhsgYo9Leit6BomhWYUywnaGDZDvLtqv5zlIx971hTBG9zxWRueoOZk5dTQinH8%2FK7LfWJYKBCSnW9AAtvew%3D%3D&pageNo=1&numOfRows=500&apiType=JSON&create_dt=2022-08-29'


response = urllib.request.urlopen(url)

response_message = response.read().decode('utf8')

data = json.loads(response_message)

json_arr = data['items']
#json_arr = data['data']
#print(json_arr)

#for item in json_arr:
#    print(item)

conn = pymysql.connect(host='localhost',
                           user='root',
                           password='1234',
                           db='springpj',
                           charset='utf8')

sql = 'insert into covid values("%s", "%s", "%s", "%s", "%s", "%s", "%s")'

cur = conn.cursor()
for item in json_arr:
    cur.execute(sql % ( item['criticalRate'], item['death'],item['deathRate'],item['confCaseRate'],item['createDt'],item['confCase'],item['gubun']) )
    conn.commit()      # json 같은 경우에는 'data', '연번', '서명', '가격' 같이 속성명을 직접 적음

conn.close()