from flask import Flask
from flask import request
import pymysql

app = Flask(__name__)

uName=""
uP=0
connection=null

def load():
    with open('','r') as f:
        uName=f.read()
        uP=f.read()
    f.close

def connectDB():
    connection = pymysql.connect(host='localhost',
                             user=uName,
                             password=uP,
                             db='db',
                             charset='utf8mb4',
                             cursorclass=pymysql.cursors.DictCursor)


@app.route("/GetScores", methods=['GET'])
def retieve_score():
    with connection.cursor() as cursor:
        sql = "SELECT 'username', 'score' FROM 'ranking' ORDER BY score DESC LIMIT 10"
        cursor.execute(sql)
        result = cursor.fetchall()
    return result


@app.route('/uploadScores', methods=['POST'])
def upload_score():
    userName = request.values['username']
    userScore = request.values['userscore']

    try:
        with connection.cursor() as cursor:
            # Create a new record
            sql = "INSERT INTO 'ranking' ('username', 'score') VALUES (%s, %s)" #using the %s to prevent sql injection
            cursor.execute(sql, (userName, userScore))

    connection.commit()
   

load()
app.run(host='0.0.0.0', port=8080)