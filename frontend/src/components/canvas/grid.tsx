import { FunctionalComponent } from 'vue';

export interface GridProps {
  gridId: string;
  subGridId?: string;
  scale?: number;
  x: number;
  y: number;
  width?: string;
  height?: string;
  size?: number;
  subGridSize?: number;
  color?: string;
}

const CanvasGrid: FunctionalComponent<GridProps> = ({
  gridId,
  subGridId = gridId + '_small',
  x,
  y,
  scale = 1,
  width = '100%',
  height = '100%',
  size = 64 * scale,
  subGridSize = 8 * scale,
  color = '#0000003F',
}: GridProps) => (
  <>
    <defs>
      <pattern
        id={subGridId}
        width={subGridSize}
        height={subGridSize}
        patternUnits="userSpaceOnUse"
      >
        <path
          d={`M0,0 v${subGridSize} h${subGridSize}`}
          stroke-width="1"
          stroke={color}
          fill="none"
        />
      </pattern>

      <pattern
        id={gridId}
        x={x % size}
        y={y % size}
        width={size}
        height={size}
        patternUnits="userSpaceOnUse"
      >
        <rect
          width={width}
          height={height}
          fill={`url(#${subGridId})`}
        ></rect>
        <path
          d={`M0,0 v${size} h${size}`}
          stroke-width="1"
          stroke={color}
          fill="none"
        />
      </pattern>
    </defs>
    <rect width={width} height={height} fill={`url(#${gridId})`}></rect>
  </>
);

export default CanvasGrid;