BIP39.NET
===========

C# (PCL) implementation of the BIP39 Bitcoin Improvement Proposal Document https://github.com/bitcoin/bips/blob/master/bip-0039.mediawiki

This PCL is targeted for Universal Apps (Windows 8.1/Windows Phone 8.1) and .NET 4.5.1 ONLY. No support for Windows 8 or Windows Phone 8/8.1 Silverlight apps

### PLEASE ENSURE YOU ALSO DOWNLOAD, BUILD AND REFERENCE THE BitcoinUtilities.NET PROJECT LOCATED HERE: https://github.com/Thashiznets/BitcoinUtilities.NET ###

I have included a test GUI which shows you how to use the BIP39 class.

I have created unit tests that test against the English and Japanese test vectors posted here https://raw.githubusercontent.com/trezor/python-mnemonic/master/vectors.json and here https://github.com/Thashiznets/bip32JP.github.io/blob/patch-1/test_JP_BIP39.json

PBKDF2-HMACSHA512 functionality provided by my PWDTK.NET project, it is a slightly modified variant of the rfc2898 class when compared to PWDTK.NET as the BIP39 spec has us use the mnemonic sentence as the hmac key and then we just hash the word "mnemonic"+[user-supplied-passphrase] for 2048 iterations, whereas PWDTK.NET would have you use the passphrase as the hmac key and hash the mnemonic sentence + crypto random salt over x iterations. Six to one Half Dozen to the other really as all are creating irreversible bits with stretching as is the aim.

This code is put out for all to use for free, I don't have a great deal of Bitcoin but I'd really like some so if you find yourself using this code in a commercial implementation and you feel you are going to make some money from it, I’d appreciate it if you fling me some bitcoin to 1ETQjMkR1NNh4jwLuN5LxY7bbip39HC9PUPSV thanks :)
