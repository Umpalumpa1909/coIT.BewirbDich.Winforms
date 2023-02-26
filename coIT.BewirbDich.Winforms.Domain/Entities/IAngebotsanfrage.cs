namespace coIT.BewirbDich.Winforms.Domain.Entities;

public interface IAngebotsanfrage
{
    Angebotsanfrage Angebotsanfrage { get; }
    decimal VersicherungsSumme { get; }

    VersicherungsKonditionen BerechneKonditionen();
}