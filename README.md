QuickGameFinder est une plateforme permettant aux joueurs n'ayant pas de cohéquipier avec lequel jouer de trouver rapidement une équipe qui correspond à ses attentes pour lancer une partie sans avoir la mauvaise surprise de tomber avec une équipe bancale du au hasard du matchmaking des jeux en ligne.

Ce projet est réalisé en C# WinForm.

Comment ça fonctionne :

Ce projet repose sur une structure réseau utilisant le protocole TCP. Ce protocole est souvent utilisé dans les jeux comme World Of Warcraft pour transmettre des packets réseau du client au serveur et inversement en temps réel sans a avoir a passer par des requêtes POST et GET a une API.

Dans notre cas le serveur aura le contrôle des connexions, inscriptions, la gestion des salons, les messages etc...

Ce projet fût ma première expérience avec la notion de programmation orientée réseau. J'en ai beaucoup appris et ce fût très enrichissant pour les projets qui suivront.

Il faut par conséquent noter que l'optimisation n'était clairement pas au rendez-vous dans ce projet.

![alt text](https://i.ibb.co/R6z9LHk/chargement.png)
![alt text](https://i.ibb.co/SvNhrLp/CONNEXION.png)
![alt text](https://i.ibb.co/n7QkrgW/PREMIEREPAGEVIDE.png)
![alt text](https://i.ibb.co/0hFdVgF/CREATEGRP.png)
![alt text](https://i.ibb.co/vHf0Dxs/PREMIEREPAGEPLEINE.png)
![alt text](https://i.ibb.co/Cm4Bv86/Chat.png)
![alt text](https://i.ibb.co/f2G9vtt/MISSINGAME2.png)
![alt text](https://i.ibb.co/mTbw0DD/Serv.png)
