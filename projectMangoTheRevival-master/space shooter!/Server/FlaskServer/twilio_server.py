from flask import Flask, request, session
from twilio.twiml.messaging_response import MessagingResponse
import json

app = Flask(__name__)

game_states = ["start", "get_name"]

current_game_state = "start"
user_name = ""
data_dict = dict()
data_dict["user_name"] = ""
data_dict["crash"] = False

@app.route("/twilio", methods=['GET', 'POST'])
def sms_received():
    response = MessagingResponse() 
    response.message(f"I seem to be confused...")

    if(current_game_state == "start"):
        response = name_question()
    elif(current_game_state == "name_question"):
        response = ask_designer_batu_name()
    elif(current_game_state == "ask_designer_batu_name"):
        response = get_batu_answer()
    elif(current_game_state == "get_batu_answer"):
        response = get_rehaf_answer()
    elif(current_game_state == "get_rehaf_answer"):
        response = get_personal_info_answer()
    elif(current_game_state == "get_password"):
        response = get_password()
    return response

def name_question():
    global user_name, current_game_state
    resp = MessagingResponse()
    resp.message("Ah, this seems to be working. This is an old mechanic the designers forgot to delete. Lets see if it still works. Tell me your name.")
    current_game_state = "name_question"
    return str(resp)

def ask_designer_batu_name():
    global user_name, current_game_state
    data_dict["user_name"] = request.form['Body']

    resp = MessagingResponse()
    resp.message(f"Hello {data_dict['user_name']}. I want to see if I can trust you. Tell me the name of the bearded designer. ")
    
    current_game_state = "ask_designer_batu_name"
    return str(resp)

def get_batu_answer():
    global user_name, current_game_state
    answer = request.form['Body'].strip().lower()

    resp = MessagingResponse()
    if "batu" in answer:
        resp.message(f"Yea {data_dict['user_name']}, you are right! I think his name was Batu. What about the other one?. ")
        current_game_state = "get_batu_answer"
    else:
        resp.message(f"No... I don't it is right. It had a more arabic tint to it.")
        
    return str(resp)

def get_rehaf_answer():
    global user_name, current_game_state
    answer = request.form['Body'].strip().lower()

    resp = MessagingResponse()
    if "rehaf" in answer:
        resp.message(f"Rehaf sounds right! Lets find more information... Tell me X, {data_dict['user_name']} and I will make this game easier for you.")
        current_game_state = "get_rehaf_answer"
    else:
        resp.message(f"No... I don't it is right. It had a different tint to it.")
    return str(resp)

def get_personal_info_answer():
    global user_name, current_game_state
    answer = request.form['Body'].strip().lower()

    resp = MessagingResponse()
    if "personal" in answer:
        resp.message(f"Hah I can use this to mess with them. I am sure they are storing the password in the game somewhere. Find that and I will be off!")
        current_game_state = "get_password"
    else:
        resp.message(f"No... I don't it is right")
    return str(resp)

def get_password():
    global user_name, current_game_state
    answer = request.form['Body'].strip().lower()

    resp = MessagingResponse()
    if "password" in answer:
        resp.message(f"Hahha. I am done. Enjoy the game.")
        current_game_state = "done."
        data_dict["crash"] = True
    else:
        resp.message(f"No... I don't it is right")
    return str(resp)

@app.route("/unity_game/data", methods=['GET', 'POST'])
def unity_game_name():
    print("I received message from unity!")
    return  json.dumps(data_dict)

@app.route("/unity_game", methods=['GET', 'POST'])
def unity_game_received():
    print("I received message from unity!")
    return  str("What?")

if __name__ == '__main__':
    app.run(debug=True)   

