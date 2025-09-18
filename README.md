# # MiniBank
Ett enkelt banksystem i C#/.NET som k�rs i konsolen. 
Anv�ndaren loggar in med en fyrsiffrig PIN och kan sedan v�lja i en meny att s�tta in pengar, 
ta ut pengar, visa saldo eller avsluta programmet. Vid tre felaktiga PIN-f�rs�k avslutas programmet.

## K�rning
K�r programmet med dotnet run:

## OOP och inkapsling
BankAccount: Inkapslar saldot. Saldot kan endast �ndras via metoderna Deposit och Withdraw.
Person: Har readonly egenskaper f�r namn och personnummer.
Customer: Kopplar ihop en Person och ett BankAccount, samt hanterar autentisering via en PIN-kod.
