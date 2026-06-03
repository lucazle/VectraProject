namespace SistemaFuncionarios.Domain.Exceptions {
    public class DuplicateException :DomainException {
        public DuplicateException(string message) : base(message) { }
    }
}
