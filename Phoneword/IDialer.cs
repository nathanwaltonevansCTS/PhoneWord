namespace Phoneword
{
    public interface IDialer
    {
        //prompts the user with a yes or no to dial
        //the translated number in a pop up window
        bool Dial(string number);
    }
}