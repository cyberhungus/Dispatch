internal class State_AcceptCall : Interface_State
{
    public void onEnter()
    {
        GameLogicManager.getInstance().activateButton();
        GameLogicManager.getInstance().rayCastingMode("off");
        GameLogicManager.getInstance().getSoundManager().playPhoneRinging();
    }

    public void onExecute()
    {
        
    }

    public void onExit()
    {
        GameLogicManager.getInstance().deactivateButton();
        GameLogicManager.getInstance().getSoundManager().playPhoneBabble();
    }

    public string toString()
    {
        return "State Accept Call";
    }
}