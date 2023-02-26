using coIT.BewirbDich.Domain.Enums;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Queries;

public sealed record VersicherungsVorgangResponse(Guid Id,
                                                  VorgangsStatus VorgangsStatus,
                                                  Berechnungsart Berechnungsart,
                                                  decimal VersicherungsSumme,
                                                  decimal GrundBeitrag,
                                                  decimal RisikoAufschlag,
                                                  decimal ZusatzschutzAufschlag,
                                                  decimal WebShopAufschlag,
                                                  decimal GesamtBeitrag,
                                                  DateTime? VersicherungsScheinErstellungsdatum,
                                                  int? Versicherungsnummer);