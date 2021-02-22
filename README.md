# __Domus __VR__

Interconnecter le Virtuel et le Réel 

Le projet mère : Maison Intelligente

Une solution domotique privé

Pour bien comprendre dans quelle démarche notre projet s’intègre, il faut parler d’un autre projet encadré également par M. Pêcheux nommé Maison Intelligente. Notre projet est le prolongement de celui-ci dont l’idée principale est de pouvoir commander des capteurs/actionneurs d’une maison sans qu’aucune donnée ne sorte de celle-ci. On trouve sur le marché de l’objet connecté grand public des solutions pour connecter et commander des appareils (exemple : passerelles vendues par Ikea, Phillips ou Xiaomi). Le problème est que celles-ci font fuiter les données collectées par les appareils présents dans la maison vers leurs entreprises. Cela pose des questions sur la protection des données et leur utilisation à des fins commerciales. L’idée est donc de créer une solution alternative donnant accès aux mêmes fonctionnalités mais avec des données qui restent dans le périmètre de la maison. La fonctionnalité principale étant d’avoir une interface utilisateur personnalisable sur laquelle on peut lire les données capteurs et modifier l’état des actionneurs.

Le prolongement de ce projet consiste alors à fournir une nouvelle interface permettant de visualiser et de commander les actionneurs/capteurs, initialement sur Jeedom au profit d’une représentation virtuelle. Ce monde virtuel serait construit en utilisant Unity. Ces deux projets se recouvre donc pendant le processus de récupération des données.. Au lieu d'être récupéré par un serveur Jeedom local, le but est de récupérer/poster les données depuis le casque sur un broker MQTT extrait de ce Jeedom local.

Ce projet est né de la curiosité quant à l’interconnexion entre réalité et virtuel. Le but à long terme serait de faire de la réalité augmentée avec des lunettes HoloLens. Notre projet Domus VR constitue une étape intermédiaire dans cette entreprise. Le but étant de faire un premier pas vers une solution qui interconnecte réalité et virtuel. 


