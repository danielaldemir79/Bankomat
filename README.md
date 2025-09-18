# # MiniBank
Ett enkelt banksystem i C#/.NET som körs i konsolen. 
Användaren loggar in med en fyrsiffrig PIN och kan sedan välja i en meny att sätta in pengar, 
ta ut pengar, visa saldo eller avsluta programmet. Vid tre felaktiga PIN-försök avslutas programmet.

## Körning
Kör programmet med dotnet run:

## OOP och inkapsling
BankAccount: Inkapslar saldot. Saldot kan endast ändras via metoderna Deposit och Withdraw.
Person: Har readonly egenskaper för namn och personnummer.
Customer: Kopplar ihop en Person och ett BankAccount, samt hanterar autentisering via en PIN-kod.
