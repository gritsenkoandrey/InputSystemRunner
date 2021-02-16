public abstract class BaseController
{
    protected readonly UInterface uInterface;
    protected BaseController()
    {
        uInterface = new UInterface();
    }

    public bool IsActive { get; private set; }

    public virtual void On()
    {
        On(null);
    }

    public virtual void On(params BaseModel[] model)
    {
        IsActive = true;
    }

    public virtual void Off()
    {
        IsActive = false;
    }

    public void Switch(params BaseModel[] model)
    {
        if (!IsActive)
        {
            On(model);
        }
        else
        {
            Off();
        }
    }
}