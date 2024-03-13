import { SetupContext } from 'vue';

export interface SelectedBoxProps {
  x: number,
  y: number,
  width: number,
  height: number,
  onCornerClick?(event: PointerEvent): void
}
export default function CanvasSelectedBox({
  x,y,
  width,
  height,
}: SelectedBoxProps, context: SetupContext) {

  const cornerBoxSize = 8;
  return (
    <> 
      <g width={width} height={height} x={x} y={y} onPointerdown={ e => context.emit('corner-click', e)}>
        <rect x={x} y={y} width={width} height={height} fill="none" stroke="#009FB7" stroke-width="3"/>
        <rect x={x - cornerBoxSize/2} y={y - cornerBoxSize/2} width={cornerBoxSize} height={cornerBoxSize} fill="white" stroke="#009FB7" stroke-width="1"/>
        <rect x={x+width - cornerBoxSize/2} y={y - cornerBoxSize/2} width={cornerBoxSize} height={cornerBoxSize} fill="white" stroke="#009FB7" stroke-width="1"/>
        <rect x={x - cornerBoxSize/2} y={y+height - cornerBoxSize/2} width={cornerBoxSize} height={cornerBoxSize} fill="white" stroke="#009FB7" stroke-width="1"/>
        <rect x={x+width - cornerBoxSize/2} y={y+height - cornerBoxSize/2} width={cornerBoxSize} height={cornerBoxSize} fill="white" stroke="#009FB7" stroke-width="1"/>
      </g>
    </>
  );
}