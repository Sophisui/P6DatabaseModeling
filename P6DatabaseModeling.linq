<Query Kind="Statements">
  <Connection>
    <ID>55255a52-f1ff-43da-8289-9a844b64932b</ID>
    <NamingServiceVersion>3</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Server>localhost\SQLEXPRESS</Server>
    <Database>NexaWorks</Database>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

//En cours
var ticketsEnCours = Tickets
    .Where(t => t.TicketStatus.Libelle == "En cours")
    .Dump("Tickets en cours");

//En cours + produit
var ticketsEnCoursProduit = Tickets
    .Where(t => t.TicketStatus.Libelle == "En cours")
    .Where(t => t.ProductOSVersion.Product.Libelle == "Trader en Herbe")
    .Dump("Tickets en cours pour un produit");

//En cours + produit + version
var ticketsEnCoursProduitVersion = Tickets
    .Where(t => t.TicketStatus.Libelle == "En cours")
    .Where(t => t.ProductOSVersion.Product.Libelle == "Trader en Herbe")
    .Where(t => t.ProductOSVersion.Version.Libelle == "1.3")
    .Dump("Tickets en cours pour produit et version");

//Resolus
var ticketsResolus = Tickets
    .Where(t => t.TicketStatus.Libelle == "Résolu")
    .Dump("Tickets résolus");

//Resolus + produit + periode
var ticketsResolusPeriode = Tickets
    .Where(t => t.TicketStatus.Libelle == "Résolu")
    .Where(t => t.ProductOSVersion.Product.Libelle == "Trader en Herbe")
    .Where(t => t.DateResolution >= new DateTime(2026, 1, 1)
             && t.DateResolution <= new DateTime(2026, 2, 28))
    .Dump("Tickets résolus pour produit sur période");

//Mots-cles
var motsCles = new List<string> { "Crash", "Sync" };
var ticketsAvecMotsCles = Tickets
    .Where(t => motsCles.Any(k => t.Probleme.Contains(k)))
    .Dump("Tickets avec mots-clés");
