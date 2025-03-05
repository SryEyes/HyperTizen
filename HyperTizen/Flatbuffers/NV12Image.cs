// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace hyperhdrnet
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public struct NV12Image : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_25_2_10(); }
  public static NV12Image GetRootAsNV12Image(ByteBuffer _bb) { return GetRootAsNV12Image(_bb, new NV12Image()); }
  public static NV12Image GetRootAsNV12Image(ByteBuffer _bb, NV12Image obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public NV12Image __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public byte DataY(int j) { int o = __p.__offset(4); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int DataYLength { get { int o = __p.__offset(4); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDataYBytes() { return __p.__vector_as_span<byte>(4, 1); }
#else
  public ArraySegment<byte>? GetDataYBytes() { return __p.__vector_as_arraysegment(4); }
#endif
  public byte[] GetDataYArray() { return __p.__vector_as_array<byte>(4); }
  public byte DataUv(int j) { int o = __p.__offset(6); return o != 0 ? __p.bb.Get(__p.__vector(o) + j * 1) : (byte)0; }
  public int DataUvLength { get { int o = __p.__offset(6); return o != 0 ? __p.__vector_len(o) : 0; } }
#if ENABLE_SPAN_T
  public Span<byte> GetDataUvBytes() { return __p.__vector_as_span<byte>(6, 1); }
#else
  public ArraySegment<byte>? GetDataUvBytes() { return __p.__vector_as_arraysegment(6); }
#endif
  public byte[] GetDataUvArray() { return __p.__vector_as_array<byte>(6); }
  public int Width { get { int o = __p.__offset(8); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int Height { get { int o = __p.__offset(10); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int StrideY { get { int o = __p.__offset(12); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public int StrideUv { get { int o = __p.__offset(14); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }

  public static Offset<hyperhdrnet.NV12Image> CreateNV12Image(FlatBufferBuilder builder,
      VectorOffset data_yOffset = default(VectorOffset),
      VectorOffset data_uvOffset = default(VectorOffset),
      int width = 0,
      int height = 0,
      int stride_y = 0,
      int stride_uv = 0) {
    builder.StartTable(6);
    NV12Image.AddStrideUv(builder, stride_uv);
    NV12Image.AddStrideY(builder, stride_y);
    NV12Image.AddHeight(builder, height);
    NV12Image.AddWidth(builder, width);
    NV12Image.AddDataUv(builder, data_uvOffset);
    NV12Image.AddDataY(builder, data_yOffset);
    return NV12Image.EndNV12Image(builder);
  }

  public static void StartNV12Image(FlatBufferBuilder builder) { builder.StartTable(6); }
  public static void AddDataY(FlatBufferBuilder builder, VectorOffset dataYOffset) { builder.AddOffset(0, dataYOffset.Value, 0); }
  public static VectorOffset CreateDataYVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateDataYVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDataYVectorBlock(FlatBufferBuilder builder, ArraySegment<byte> data) { builder.StartVector(1, data.Count, 1); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDataYVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<byte>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDataYVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddDataUv(FlatBufferBuilder builder, VectorOffset dataUvOffset) { builder.AddOffset(1, dataUvOffset.Value, 0); }
  public static VectorOffset CreateDataUvVector(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); for (int i = data.Length - 1; i >= 0; i--) builder.AddByte(data[i]); return builder.EndVector(); }
  public static VectorOffset CreateDataUvVectorBlock(FlatBufferBuilder builder, byte[] data) { builder.StartVector(1, data.Length, 1); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDataUvVectorBlock(FlatBufferBuilder builder, ArraySegment<byte> data) { builder.StartVector(1, data.Count, 1); builder.Add(data); return builder.EndVector(); }
  public static VectorOffset CreateDataUvVectorBlock(FlatBufferBuilder builder, IntPtr dataPtr, int sizeInBytes) { builder.StartVector(1, sizeInBytes, 1); builder.Add<byte>(dataPtr, sizeInBytes); return builder.EndVector(); }
  public static void StartDataUvVector(FlatBufferBuilder builder, int numElems) { builder.StartVector(1, numElems, 1); }
  public static void AddWidth(FlatBufferBuilder builder, int width) { builder.AddInt(2, width, 0); }
  public static void AddHeight(FlatBufferBuilder builder, int height) { builder.AddInt(3, height, 0); }
  public static void AddStrideY(FlatBufferBuilder builder, int strideY) { builder.AddInt(4, strideY, 0); }
  public static void AddStrideUv(FlatBufferBuilder builder, int strideUv) { builder.AddInt(5, strideUv, 0); }
  public static Offset<hyperhdrnet.NV12Image> EndNV12Image(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<hyperhdrnet.NV12Image>(o);
  }
}


static public class NV12ImageVerify
{
  static public bool Verify(Google.FlatBuffers.Verifier verifier, uint tablePos)
  {
    return verifier.VerifyTableStart(tablePos)
      && verifier.VerifyVectorOfData(tablePos, 4 /*DataY*/, 1 /*byte*/, false)
      && verifier.VerifyVectorOfData(tablePos, 6 /*DataUv*/, 1 /*byte*/, false)
      && verifier.VerifyField(tablePos, 8 /*Width*/, 4 /*int*/, 4, false)
      && verifier.VerifyField(tablePos, 10 /*Height*/, 4 /*int*/, 4, false)
      && verifier.VerifyField(tablePos, 12 /*StrideY*/, 4 /*int*/, 4, false)
      && verifier.VerifyField(tablePos, 14 /*StrideUv*/, 4 /*int*/, 4, false)
      && verifier.VerifyTableEnd(tablePos);
  }
}

}
