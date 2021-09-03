SELECT        dbo.Eroi.Nome, dbo.Eroi.Livello, dbo.Eroi.Punti, dbo.Eroi.IdCategorie, dbo.Eroi.IdArmi, dbo.Eroi.IdUtenti, dbo.PuntiVita.PuntiVita, dbo.Utenti.Nickname, dbo.Utenti.Admin, dbo.Eroi.Id
FROM            dbo.Eroi INNER JOIN
                         dbo.PuntiVita ON dbo.Eroi.Livello = dbo.PuntiVita.Livello INNER JOIN
                         dbo.Utenti ON dbo.Eroi.IdUtenti = dbo.Utenti.Id

						 SELECT TOP(10)        dbo.Eroi.Nome, dbo.Eroi.Livello, dbo.Eroi.Punti, dbo.Eroi.IdCategorie, dbo.Eroi.IdArmi, dbo.Eroi.IdUtenti, dbo.PuntiVita.PuntiVita, dbo.Utenti.Nickname, dbo.Utenti.Admin, dbo.Eroi.Id
FROM            dbo.Eroi INNER JOIN
                         dbo.PuntiVita ON dbo.Eroi.Livello = dbo.PuntiVita.Livello INNER JOIN
                         dbo.Utenti ON dbo.Eroi.IdUtenti = dbo.Utenti.Id
ORDER BY Livello DESC, Punti DESC