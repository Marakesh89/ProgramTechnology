using ConsoleApp1;

namespace bank;

internal class GiftCartAccount:BankAccount
{
    private readonly decimal _mouthlyDeposit = 0m;
    // mouthlyDeposit по умолчанию принимает ноль,
    // при создании new GiftCartAccount("Dany", 20000) - mouthlyDeposit =0
    // new GiftCartAccount ("Dany", 20000, 5000); => mouthlyDeposit = 5000
    public GiftCartAccount(string name, decimal initialBalance, decimal mouthlyDepozit = 0) 
        : base(name, initialBalance) 
        => _mouthlyDeposit = mouthlyDepozit;

    public override void PerformMouthAndTransactions()
    {
        if (_mouthlyDeposit != 0)
        {
            MakeDeposite(_mouthlyDeposit, DateTime.UtcNow, "Add mouth deposit");
        }
    }

    public override string ToString()
    {
        return base.ToString() +$"mouthly deposite: {_mouthlyDeposit}";
    }
}
