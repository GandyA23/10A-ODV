/**
 * Clase que se va a encargar de heredar las funciones en los estados para la State Machine
 */
public abstract class State 
{
    public abstract void Enter();    
    public abstract void Tick(float deltaTime);
    public abstract void Exit();
}
