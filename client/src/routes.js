import React from 'react';
import {BrowserRouter, Route, Switch} from 'react-router-dom';

import Welcome from './pages/Welcome';
import Video from './pages/Video';
import TagVideo from './pages/TagVideo';

export default function Routes(){
    return(
        <BrowserRouter>
            <switch>
                <Route path="/" exact component={Welcome}/>
                <Route path="/video" component={Video}/>
                <Route path="/tagvideo" component={TagVideo}/>                
            </switch>
        </BrowserRouter>
    );
}