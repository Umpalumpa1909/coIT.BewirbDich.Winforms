using coIT.BewirbDich.Winforms.Application.Abstractions.Messaging;

namespace coIT.BewirbDich.Winforms.Application.VersicherungsVorgaenge.Queries;

public sealed record GetVersicherungsvorgangByIdQuery(Guid VersicherungsVorgangId) :
    IQuery<VersicherungsVorgangResponse>;