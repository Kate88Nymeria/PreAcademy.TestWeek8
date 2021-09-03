SELECT       TOP (10)  dbo.Eroi.Id, dbo.Eroi.Nome, dbo.Eroi.Livello, dbo.Eroi.Punti, dbo.Eroi.IdUtenti, dbo.Utenti.Id AS Expr1, dbo.Utenti.Nickname, dbo.Utenti.Admin, dbo.Armi.Nome AS Expr2, dbo.Categorie.Nome AS Expr3, 
                         dbo.PuntiVita.PuntiVita
FROM            dbo.Eroi INNER JOIN
                         dbo.Utenti ON dbo.Eroi.IdUtenti = dbo.Utenti.Id INNER JOIN
                         dbo.Armi ON dbo.Eroi.IdArmi = dbo.Armi.Id INNER JOIN
                         dbo.Categorie ON dbo.Eroi.IdCategorie = dbo.Categorie.Id AND dbo.Armi.IdCategorie = dbo.Categorie.Id INNER JOIN
                         dbo.PuntiVita ON dbo.Eroi.Livello = dbo.PuntiVita.Livello
ORDER BY dbo.Eroi.Livello DESC, dbo.Eroi.Punti DESC