using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutContainer : MonoBehaviour
{
    public Sprite[] Sprites;
    public TileContainer P_TileContainer;

    public Layout Layout { get; set; }
    public TileContainer[,] TileContainers { get; private set; }

    public Texture2D BP;
    public Texture2D BP2;

    // TODO: FIX HACK
    public static LayoutContainer Inst;
    private void Awake()
    {
        Inst = this;
    }

    public void GenerateTiles( Layout layout )
    {

        //Layout = layout;

        Layout = BlueprintReader.Read(BP, BP2);

        TileContainers = new TileContainer[Layout.Width, Layout.Height];

        for (int y = 0; y < Layout.Height; y++)
        {
            for (int x = 0; x < Layout.Width; x++)
            {
                Tile tile = Layout.Tiles[x, y];
                if (tile != null)

                CreateTileContainer(y, x);
            }
        }

        CreateTileObjectContainers();
    }

    private void CreateTileContainer(int y, int x)
    {
        TileContainer tileContainer = Instantiate(P_TileContainer);

        tileContainer.transform.SetParent(transform, false);

        tileContainer.Init(Layout.Tiles[x, y]);

        TileContainers[x, y] = tileContainer;
    }

    private void CreateTileObjectContainers( )
    {
        print( Layout.TileObjectsID.Count );

        foreach (var tileObject in Layout.TileObjectsID)
        {
            CreateTileObjectContainer( tileObject );
        }
    }

    private void CreateTileObjectContainer( Tuple<string, Vector2Int> tileObject)
    {
        print( tileObject );

        GameObject obj = Instantiate(Resources.Load<GameObject>( tileObject.First ) );

        obj.transform.SetParent( transform, false );

        obj.GetComponent<TileObject>().Init( tileObject.Second );
    }

    private void GasFill( int x, int y, Layout layout, float newVal )
    {
        if (x < 0 || x >= layout.Width) return;
        if (y < 0 || y >= layout.Height) return;

        Tile tile = layout.Tiles[x, y];
        if (tile.Atmoshpere != newVal)
        {
            tile.Atmoshpere = newVal;

            GasFill(x, y - 1, layout, newVal);
            GasFill(x + 1, y, layout, newVal);
            GasFill(x, y + 1, layout, newVal);
            GasFill(x - 1, y, layout, newVal);
        }
    }
}
