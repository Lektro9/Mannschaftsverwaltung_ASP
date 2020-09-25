import random

# genereate SQL Inserts

# insert Mannschaften

Mannschaftsnamen = ["FCBayern", "Schalke04", "Kickers", "Kickers2006", "Die Teufel", "Cornwall Snakes", "Blue Snakes", "Bold Rabbits", "Modest Foxes", "Dubai Green Jackets", "Green Donkeys", "Considerate Horses", "Considerate Dodgers", "Canada Pink Legs", "Splendid Mice", "Malicious Goldfish", "Remarkable Angels", "London Toads", "Understanding Lizards", "Ruthless Moths"]
sportArten = ["Fussball", "Handball", "Tennis" ]


InsertMann = """
INSERT INTO `mannschaft` (`id`, `name`, `sportart`, 
`session_id`, `Unentschieden`, `GewSpiele`, `VerlSpiele`, `ErzielteTore`, `GegnerischeTore`) 
VALUES (NULL, '{}', '{}', '1', '0', '0', '0', '0', '0');
"""

# for index in range(len(Mannschaftsnamen)):
#     print(InsertMann.format(Mannschaftsnamen[index], sportArten[random.randint(0, 2)]))


# insert Persons

persons = [
{"first_name":"Iver","last_name":"Blandamere","gebDatum":"5-2-2020"},
{"first_name":"Olivero","last_name":"Philip","gebDatum":"7-4-2020"},
{"first_name":"Pam","last_name":"Conklin","gebDatum":"10-19-2019"},
{"first_name":"Paolo","last_name":"Hiland","gebDatum":"9-10-2020"},
{"first_name":"Maxy","last_name":"Dellenty","gebDatum":"2-28-2020"},
{"first_name":"Merry","last_name":"Gallemore","gebDatum":"1-9-2020"},
{"first_name":"Harli","last_name":"Eakins","gebDatum":"11-20-2019"},
{"first_name":"Fifi","last_name":"Nerheny","gebDatum":"12-23-2019"},
{"first_name":"Bertrand","last_name":"Breche","gebDatum":"7-3-2020"},
{"first_name":"Vinny","last_name":"Nesbit","gebDatum":"8-30-2020"},
{"first_name":"Nancey","last_name":"Ilyenko","gebDatum":"9-10-2020"},
{"first_name":"Sheilakathryn","last_name":"Brabender","gebDatum":"5-15-2020"},
{"first_name":"Kellyann","last_name":"Wintle","gebDatum":"10-27-2019"},
{"first_name":"Shanta","last_name":"Gilhespy","gebDatum":"3-10-2020"},
{"first_name":"Blair","last_name":"Brookwood","gebDatum":"2-16-2020"},
{"first_name":"Dell","last_name":"Poleye","gebDatum":"7-18-2020"},
{"first_name":"Daloris","last_name":"Walewicz","gebDatum":"5-20-2020"},
{"first_name":"Faustina","last_name":"Ariss","gebDatum":"11-18-2019"},
{"first_name":"Brand","last_name":"Draper","gebDatum":"5-3-2020"},
{"first_name":"Theodor","last_name":"Ailmer","gebDatum":"7-9-2020"}
]

teamIDs = [
{"id":"1337"},
{"id":"7167"},
{"id":"47521"},
{"id":"156033"},
{"id":"171524"},
{"id":"171568"},
{"id":"171569"},
{"id":"171570"},
{"id":"171571"},
{"id":"171572"},
{"id":"171573"},
{"id":"171574"},
{"id":"171575"},
{"id":"171576"},
{"id":"171577"},
{"id":"171578"},
{"id":"171579"},
{"id":"171580"},
{"id":"171581"},
{"id":"171582"}
]

InsertPerson = """
INSERT INTO `person` (`id`, `vorname`, `name`, `geburtstag`, `mannschaft_id`, `session_id`) 
VALUES (NULL, '{}', '{}', '{}', {}, '1');
"""

for index in range(len(persons)):
    print(InsertMann.format(persons[index]["first_name"], 
    persons[index]["last_name"], 
    persons[index]["gebDatum"], 
    int(teamIDs[index]["id"]
    )))
