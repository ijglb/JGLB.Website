window.onresize = () => {
    DotNet.invokeMethodAsync('JGLB.Website', 'WindowResize', window.innerWidth, window.innerHeight);
};