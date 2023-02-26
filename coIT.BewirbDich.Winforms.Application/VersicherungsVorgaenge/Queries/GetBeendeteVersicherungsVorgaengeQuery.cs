using coIT.BewirbDich.Application.Abstractions.Messaging;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Queries;

public sealed record GetBeendeteVersicherungsVorgaengeQuery(int AbVersicherungsnummer) :
    IQuery<VersicherungsVorgaengeResponse>;