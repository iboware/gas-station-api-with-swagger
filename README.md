# gas-station-api-with-swagger

It supports ODATA V4 queries A swagger UI available under your development path `/swagger/`.

Example query:
```
https://localhost:5001/TankStelle?$orderby=street&$filter=contains(street,'Flug')
```
Resulting json:

```json
[
    {
        "id": 124,
        "street": "Flughafen/Nordallee ",
        "postalCode": "51147",
        "city": "Köln",
        "latitude": "7.11290",
        "longtitude": "50.88113"
    }
]
```
