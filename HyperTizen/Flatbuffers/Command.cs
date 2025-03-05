// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace hyperhdrnet
{

public enum Command : byte
{
  NONE = 0,
  Color = 1,
  Image = 2,
  Clear = 3,
  Register = 4,
};



static public class CommandVerify
{
  static public bool Verify(Google.FlatBuffers.Verifier verifier, byte typeId, uint tablePos)
  {
    bool result = true;
    switch((Command)typeId)
    {
      case Command.Color:
        result = hyperhdrnet.ColorVerify.Verify(verifier, tablePos);
        break;
      case Command.Image:
        result = hyperhdrnet.ImageVerify.Verify(verifier, tablePos);
        break;
      case Command.Clear:
        result = hyperhdrnet.ClearVerify.Verify(verifier, tablePos);
        break;
      case Command.Register:
        result = hyperhdrnet.RegisterVerify.Verify(verifier, tablePos);
        break;
      default: result = true;
        break;
    }
    return result;
  }
}


}
