import requests

api_key = "jWoqt380wa0xYaEWb4lrKbYBgaqM7N6U"

# Example point in downtown Cincinnati (lat, lon)
latitude = 39.1031
longitude = -84.5120

url = f"https://api.tomtom.com/traffic/services/4/flowSegmentData/absolute/10/json?point={latitude},{longitude}&unit=KMPH&key={api_key}"

response = requests.get(url)

if response.status_code == 200:
    data = response.json()
    print(data)
else:
    print("Error:", response.status_code, response.text)
