import { EdgeStyle } from '../canvas/RmEdge.vue';

export interface EdgeRenderProps {
  path?: string,
  edgeStyle?: EdgeStyle
}

export default function CanvasTopic({
  path = '',
  edgeStyle = 'solid',
}: EdgeRenderProps) {

  const styleProps: Record<EdgeStyle, string> = {
    solid: '',
    dashed: '10',
    dotted: '0.1 10',
  };


  return (
    <>
      <path
        d={path}
        stroke-width={edgeStyle != 'dotted'? '4' : '6'}
        stroke-dasharray={styleProps[edgeStyle]}
        fill="none"
        stroke-linecap="round"
        stroke-linejoin="round"
        stroke="#009FB7"
      />
    </>
  );
}