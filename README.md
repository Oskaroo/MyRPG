# MyRPG

---

MyRPG is a game simulator, which makes possible to Get full list of characters, Add new, Delete, and Update them.
for this app i used technologies such as:
-Web Api
-EntityFrameworkCore
-Nunit
-Moq
-Automapper
-SQL

All services are async, to prepare for bigger apps.

![appmain](https://github.com/Oskaroo/MyRPG/assets/106118915/90c22b96-c790-43e7-bef0-9ce332054b50)

---

First service is GetAllCharacters. It makes, that you will get a list of all characters from the database.


![app1](https://github.com/Oskaroo/MyRPG/assets/106118915/190bcde0-f13a-4f07-8917-0f61fc7710ff)


---

Secondary We can get single character by using ID:

![app2](https://github.com/Oskaroo/MyRPG/assets/106118915/0dde3822-f152-465f-80a8-d4fdcccdfe19)


---

If You will type a wrong ID the app give you error, and Code will change.

![app3](https://github.com/Oskaroo/MyRPG/assets/106118915/d17d001d-891c-4441-a6d5-9b0234d0fc81)

---

Third service is a DeleteCharacter, which is giving you function, that will delete character by ID

![app4](https://github.com/Oskaroo/MyRPG/assets/106118915/ee8efd37-fc98-4862-8b20-9330a7a9423d)


---

This service, also has protection from wrong ID.

![app5](https://github.com/Oskaroo/MyRPG/assets/106118915/ae4c6cc8-af50-46db-9ddb-ab23cb33d2ea)

---

We have also AddCharacter, wchich is giving you function, that will add new character to the database

![app6](https://github.com/Oskaroo/MyRPG/assets/106118915/1eddad89-cbee-4608-844f-6511e6f4be4e)

---

And there is a protection when you type a wrong data in properties

![app7](https://github.com/Oskaroo/MyRPG/assets/106118915/0dbb6aa0-5d31-4d83-8052-7b807013507c)

---

The last service is a UpdateCharacter, which is giving you function, that will edit an existing character in database.

![app8](https://github.com/Oskaroo/MyRPG/assets/106118915/1a54c704-af42-4fbe-969e-bbe11d01f4cf)

---

Also you have a protection if you will try to edit character who doesnt exist.

![app9](https://github.com/Oskaroo/MyRPG/assets/106118915/45a0cfb2-438c-417a-8e02-4cd25d7824c3)

---
