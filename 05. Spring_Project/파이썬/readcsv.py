import csv #java의 import 같은 것
import pymysql
#data.csv 파일을
#읽어들임(r)
#encoding = utf-8 (utf-8 방식으로 읽음)
f = open("covid.csv", 'r', encoding='utf-8')
rdr = csv.reader(f) #csv값을 rdr이라는 변수에 파일값 넣음
"""for item in rdr:    #csv 파일 내용을 하나씩 읽어들임 # : 이후에 들여쓰기면 for문 안
    temp = '책제목:{}, 출판사:{}'.format(item[1], item[2])
    print(temp)
    
    #print(item)
    #print(item[1])"""

count = 0
mydata =[]
for line in rdr:
    if count==0:    #한 줄씩 읽어들이는데 첫번째 줄은 그냥 통과, continue랑 다름
        pass    #아~무 것도 안 함. continue랑은 다르게 밑에 꺼 수행함
    else:
        mydata.append(line) #첫 줄 제외하고 다 집어 넣음
    count+=1

for item in mydata:
    print(item)

f.close() #파일 관련 객체 종료시킴
# %d : 숫자, %s : 문자열
sql = 'insert into covid values("%s", "%s", "%s")'
for item in mydata:
    #pip를 켜줘야?
    conn = pymysql.connect(host='localhost',
                           user='root',
                           password='1234',
                           db='springpj',
                           charset='utf8')
    with conn: #db 연결 및 끊어주는 걸 자동으로 함. db명령수행하면 자동으로 끊김
        with conn.cursor() as cur: #conn의 cursor를 cur로 변경(db 안의 커서)
            cur.execute(
                sql % (item[0], item[1], item[2])
            )

            # strip() : 양 옆 공백 제거
            # replace : 특정 문자를 대체함. 여기선 콤마를 제거함
            print(item[0], item[1], item[2])
            conn.commit()