using coIT.BewirbDich.Winforms.Application.Abstractions.Messaging;

namespace coIT.BewirbDich.Winforms.Application.VersicherungsVorgaenge.Queries;

public sealed record GetBeendeteVersicherungsVorgaengeQuery(int AbVersicherungsnummer) :
    IQuery<VersicherungsVorgaengeResponse>;