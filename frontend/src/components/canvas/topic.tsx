import { SetupContext } from 'vue';

export interface TopicProps {
  x?: number,
  y?: number,
  width?: number,
  height?: number,
}

export default function CanvasTopic({
  x=0,
  y=0,
  width = 256,
  height = 64,
}: TopicProps, context: SetupContext) {

  function onInput(e: KeyboardEvent) {
    const el = e.target as HTMLElement;
    const lastInput = el.outerText;
    const allowedKeys = /^Delete|Backspace|Arrow(.*)$/;

    if (
      (lastInput.length >= 28 && 
      !e.key.match(allowedKeys)) ||
      (lastInput.length < 28 &&
      e.ctrlKey)
    ) {
      e.preventDefault();
    }
  }
  
  return (
    <>
      <foreignObject width={width} height={height} x={x} y={y}
        onKeydown={onInput}
        onPointerdown={e => {
          context.emit('clicked', e);
        }}
      >
        <div class="w-full h-full font-size-6 bg-brand-orange 
      fg-fg-inverted b-1px-solid-black rd-5px font-400 
      flex items-center justify-center px-14px">
          <span onPointerdown={e => e.stopPropagation()} style="font-family: 'Fredoka'; word-break: break-word;"
            class="block w-full text-center"
            contenteditable="true" 
          ></span>
        </div>
      </foreignObject>
    </>
  );
}