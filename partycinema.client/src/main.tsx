import ReactDOM from 'react-dom/client'
import 'bootstrap/dist/css/bootstrap.min.css';
import App from './App.tsx'
import { BrowserRouter } from 'react-router-dom'

import './index.scss'
import './index.css'
import { createContext } from 'react';
import UserStore from './stores/UserStore.ts';

export type ContextType = {
  user: UserStore
}

export const Context = createContext<ContextType | null>(null);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <Context.Provider value={{
    user : new UserStore()
  }}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Context.Provider>

)

/*let container : any = null;

document.addEventListener('DOMContentLoaded', function(event) {
  if (!container) {
    container = document.getElementById('root') as HTMLElement;
    const root = ReactDOM.createRoot(container)
    root.render(
      <Context.Provider
      value={{
        user: new UserStore()
      }}>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Context.Provider>
    );
  }
});
*/