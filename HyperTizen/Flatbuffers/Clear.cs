// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace hyperhdrnet
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct Clear : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_25_2_10(); }
  public static Clear GetRootAsClear(ByteBuffer _bb) { return GetRootAsClear(_bb, new Clear()); }
  public static Clear GetRootAsClear(ByteBuffer _bb, Clear obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Clear __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int Priority { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<hyperhdrnet.Clear> CreateClear(FlatBufferBuilder builder,
      int priority = 0) {
    builder.StartTable(1);
    Clear.AddPriority(builder, priority);
    return Clear.EndClear(builder);
  }

  public static void StartClear(FlatBufferBuilder builder) { builder.StartTable(1); }
  public static void AddPriority(FlatBufferBuilder builder, int priority) { builder.AddInt(0, priority, 0); }
  public static Offset<hyperhdrnet.Clear> EndClear(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<hyperhdrnet.Clear>(o);
  }
}


static public class ClearVerify
{
  static public bool Verify(Google.FlatBuffers.Verifier verifier, uint tablePos)
  {
    return verifier.VerifyTableStart(tablePos)
      && verifier.VerifyField(tablePos, 4 /*Priority*/, 4 /*int*/, 4, false)
      && verifier.VerifyTableEnd(tablePos);
  }
}

}
