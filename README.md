# LoopringUnity
## Loopring API Integration with Unity Engine


LoopringUnity is a free to use package, which can easily integrate the Loopring API into your Unity WebGL game/app. It was originally created to support the development [Loop Monsters](https://loopmon.com) game. 

Notes:
- This has been tested and working in Unity Verion 2020.3.30f1.
- You MUST switch your taget platform to WebGL (File > Build Settings).
- [Chainsafe](https://github.com/ChainSafe/) SDK is used to query an ethereum smart contract.


## Features

- Connect with Metamask, Gamestop Wallet or WalletConnect.
- Make API calls to Looprings API.
- 1 Click Import the package to have the bare essentials set up your Loopring DAPP.

## Dapps using LoopringUnity
__Submit any to admin@loopmon.com__
- Loop Monsters Alpha [Play](https://play.loopmon.com) 

## Current API Calls

These are the current Loopring API calls intergrated, if you look at the ApiCaller.cs script, you can easily add more.
(more will be added in the future).

All of the responses from these functions are stored in an object with all of its attributes.

| Function | Use |
| ------ | ------ |
| GetAPIKey | Gets users L2 API Key |
| GetAccountIDTask | Gets users account information |
| GetTokenBalance | Gets users NFT data |
| ResolveENS | [Gets Loopring ENS|
| GetMetadata | Gets Metadata from IPFS |


## Installation

1. Download and install Unity Version 2020.3.30f1 with the WebGL package.
2. Download the **LoopringUnityPackage.unitypackage** file and import it as a custom package into your unity project.
3. Ensure your project platform is set to WebGL (File > Build Settings).
4. Add the following scenes to the build settings: Login, Unlock, Main
5. Build and Run, the demo shows the first 8 characters of your L2 API key so you can verify it is correct.



## Security

Due to handling a Loopring API key, precautions are taken to ensure it stays secure. After it has been used to query the data, it is wiped from the app.
You **ALWAYS** want to ensure your API and Privatekey are being handled safely, if you open the network tab (f12), you can see where the API key is being sent (Looprings API), if you notice an app that sends data to an external location, **PLEASE REPORT IT IMMEDIATELY** that that means your API +/ Private key has been potentially comprimised.

## Support
Feel free to raise any issues if you come across any problems, I will try to resolve them asap.

If you wish to support the project, you can follow [@LoopmonNetwork](https://twitter.com/LoopmonNetwork) on twitter, join our discord or on Reddit [r/LoopMonsters](https://www.reddit.com/r/LoopMonsters/).
Also give Fudgey a follow [@fudgeyDOTeth](https://twitter.com/fudgeyDOTeth).

## Credits
Loopmon - Signing and authentication Integration
donation address: monster.loopmon.eth

Exquoesme - Web3 Wallet Integration
donation address: exquoesme.loopring.eth

Fudgey - [PoseidonSharp](https://github.com/fudgebucket27/PoseidonSharp)
donation address: fudgey.eth


