export interface EdgeProps {
  start: { x:number,y:number },
  end: { x:number,y:number },
  format?: 'line' | 'curve',
  style?: 'solid' | 'dashed' | 'dotted'
}

export default function CanvasEdge({
  start,
  end,
  format = 'curve',
  style = 'solid',
}:EdgeProps) {
  return (
    <>
      <path d={`M${start.x},${start.y} 
      C${start.x},${end.y/2} 
      ${end.x},${end.y/2}
      ${end.x},${end.y}
      `} 
      fill="none" stroke="#009FB7" stroke-width="4"/>
    </>
  );
}