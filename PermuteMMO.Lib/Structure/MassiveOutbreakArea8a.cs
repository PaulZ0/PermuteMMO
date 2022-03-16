﻿using System.Buffers.Binary;

namespace PermuteMMO.Lib;

/// <summary>
/// Massive Mass Outbreak data for a single area, containing multiple spawners and some metadata.
/// </summary>
public readonly ref struct MassiveOutbreakArea8a
{
    public const int SIZE = 0xB80;
    private readonly Span<byte> Data;
    public const int SpawnerCount = 20;

    public MassiveOutbreakArea8a(Span<byte> data) => Data = data;

    public ulong AreaHash => BinaryPrimitives.ReadUInt64LittleEndian(Data);
    public bool IsActive => Data[0x8] == 1;

    public MassiveOutbreakSpawner8a this[int index] => new(Data.Slice(0x10 + (MassiveOutbreakSpawner8a.SIZE * index), MassiveOutbreakSpawner8a.SIZE));
}
