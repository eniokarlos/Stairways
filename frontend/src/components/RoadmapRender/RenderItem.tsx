import { SetupContext } from 'vue';
import { ItemContent, ItemType } from '../canvas/RmItem.vue';

export interface ItemRenderProps{
  id: string,
  x?: number,
  y?: number,
  width?: number,
  height?: number,
  content?: ItemContent,
  type?: ItemType
  linkTo?: string;
  label?: string;
  labelWidth?: number;
  labelSize?: number;
}

type Events = {
  itemClicked(item: ItemRenderProps): void
}

export default function CanvasTopic(props: ItemRenderProps, context: SetupContext<Events>) {
  const typeColors: Record<ItemType, {bg:string, fg:string}> = {
    topic: {
      bg: '#FF8811',
      fg: '#fff',
    },
    subTopic: {
      bg: '#FFE599',
      fg: '#000',
    },
    link: {
      bg: '#DB2763',
      fg: '#FFF',
    },
    text: {
      bg: 'transparent',
      fg: '#2E2E2E',
    },
  };

  const {
    x=0,
    y=0,
    width = 256,
    height = 64,
    type = 'topic',
    label = '',
    labelSize = 18,
    labelWidth = 500,
  } = props;

  return (
    <>
      <g cursor={'pointer'}
        onClick={() => context.emit('itemClicked', props)}
      >
        <rect
          x={x}
          y={y}
          width={width}
          height={height}
          fill={typeColors[type].bg}
          stroke={type === 'text' ? 'none' : 'black'}
          rx="5"
        />
        <text
          style="font-family: 'Fredoka'"
          alignment-baseline="middle"
          dominant-baseline="middle"
          text-anchor="middle"
          font-size={labelSize}
          font-weight={labelWidth}
          fill={typeColors[type].fg}
          x={x+width / 2}
          y={y+height / 2}
        >
          { label }
        </text>
      </g>
    </>
  );
}