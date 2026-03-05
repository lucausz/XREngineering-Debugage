
# Compte-Rendu de TP : Système Solaire Interactif en VR
Étudiants : Luca USZYNSKi et Brice PERROUT

Version : 1.2 (Architecture validée - Interactions XR fonctionnelles)

État d'avancement : Fin de l'Étape 4 (Interactions et UI)

## 1. Objectifs du Projet
Développer une application de réalité virtuelle permettant d'observer et de manipuler une simulation du système solaire. L'accent est mis sur la précision des données astronomiques (éphémérides) et l'ergonomie des interactions en VR (Meta Quest 2).

## 2. Architecture Logicielle (MVC)
Le projet suit le pattern Modèle-Vue-Contrôleur pour garantir une séparation claire entre les données et l'affichage :

Modèle (TimeModel) : Gère la date de la simulation et le facteur de vitesse temporelle.

Vue (PlanetView) : Gère la représentation 3D et le feedback visuel (étiquettes).

Contrôleurs :

PlanetSystemController : Coordonne la logique globale (positions, orbites).

ScaleController : Gère le zoom du système.

PlanetSelectionController : Gère le focus via le laser XR.

## 3. Réalisation Technique
Étape 1 & 2 : Placement et Échelles
Problématique : Les données du service PlanetEphemerisService sont en Unités Astronomiques (AU).

Solution : Utilisation d'un SolarSystemConfig (ScriptableObject) pour appliquer un DistanceScale global. Les positions brutes sont multipliées par ce facteur pour tenir dans l'espace de jeu VR (1m = 1 AU).

Étape 3 : Simulation du Temps
Implémentation du TimeController qui incrémente la date de la simulation à chaque Update.

Utilisation de la méthode AddDays(Time.deltaTime * secondsPerDay) pour permettre un écoulement fluide des orbites.

Étape 4 : Interactions XR
Manipulation de la maquette : Création d'un pivot SolarSystemRoot. L'utilisateur peut attraper un "socle" (Handle) via un XR Grab Interactable pour déplacer tout le système sans rompre la hiérarchie des planètes.

Interface de Contrôle (UI) :

Création d'un Canvas en World Space.

Configuration du Tracked Device Graphic Raycaster pour permettre l'interaction avec le laser des manettes.

Implémentation de boutons tactiles pour le Zoom +/-.

Sélection des Planètes :

Mise en place de XR Simple Interactable sur chaque planète.

Utilisation des événements Hover Entered pour afficher dynamiquement le nom de la planète ciblée sur le panneau de contrôle.

## 4. Difficultés rencontrées & Solutions
Conflit de Raycasting UI : Au départ, le laser passait à travers les boutons car le Graphic Raycaster par défaut ne gère pas les entrées XR. C'est pour cela que les boutons canvas ont été remplacé par des cubes

Gestion du Zoom : Pour éviter que le système ne disparaisse ou n'explose, une fonction de Mathf.Clamp a été intégrée pour limiter l'échelle entre 0.05 et 10.0.

## 5. Conclusion intermédiaire
À ce stade, l'application est pleinement fonctionnelle pour l'exploration. L'utilisateur peut se déplacer autour de la simulation, ajuster l'échelle pour observer les détails et identifier les astres. La prochaine étape consistera à enrichir les données affichées (vitesse, masse) et à peaufiner l'esthétique des trajectoires.
