
/// <summary>
/// �_���[�W���������߂̃f�[�^
/// </summary>
public class DamageData
{
    public float damageValue;
    public Team fromTeam;
    public DamageType damageType;
    public DamageData(float damageValue, Team fromTeam, DamageType damageType)
    {
        this.damageValue = damageValue;
        this.fromTeam = fromTeam;
        this.damageType = damageType;
    }
}
