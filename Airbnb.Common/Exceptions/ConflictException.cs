using Airbnb.Common.BuildingBlocks;

namespace Airbnb.Common.Exceptions;

public class ConflictException(Error error) : BaseException(error);