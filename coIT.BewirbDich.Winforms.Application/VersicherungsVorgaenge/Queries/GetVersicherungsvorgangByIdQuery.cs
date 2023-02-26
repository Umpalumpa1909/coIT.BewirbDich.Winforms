using coIT.BewirbDich.Application.Abstractions.Messaging;

namespace coIT.BewirbDich.Application.VersicherungsVorgaenge.Queries;

public sealed record GetVersicherungsvorgangByIdQuery(Guid VersicherungsVorgangId) :
    IQuery<VersicherungsVorgangResponse>;