window.DashboardCharts = {
  _instances: {},
  _destroy: function(id){
    if(this._instances[id]){ this._instances[id].destroy(); delete this._instances[id]; }
  },
  renderDoughnut: function(id, value, total){
    const el = document.getElementById(id);
    if(!el){ console.warn('Doughnut chart element not found:', id); return; }
    this._destroy(id);
    console.log('Render doughnut', id, value, total);
    this._instances[id] = new Chart(el, {
      type:'doughnut',
      data:{ labels:['Consultas','Resto'], datasets:[{ data:[value, Math.max(total-value,0)], backgroundColor:['#005792','#E8F4F8'], borderWidth:0 }] },
      options:{ responsive:true, maintainAspectRatio:false, cutout:'75%', plugins:{ legend:{ display:false }, tooltip:{ enabled:false } } }
    });
  },
  renderBar: function(id, labels, data){
    const el = document.getElementById(id);
    if(!el){ console.warn('Bar chart element not found:', id); return; }
    this._destroy(id);
    console.log('Render bar', id, labels, data);
    this._instances[id] = new Chart(el, { type:'bar', data:{ labels:labels, datasets:[{ label:'Consultas', data:data, backgroundColor:'#005792', borderRadius:6 }] }, options:{ responsive:true, maintainAspectRatio:false, plugins:{ legend:{ display:false } }, scales:{ y:{ beginAtZero:true, grid:{ display:true, color:'#F0F0F0' }, ticks:{ color:'#888' } }, x:{ grid:{ display:false }, ticks:{ color:'#888' } } } } });
  },
  renderLineMulti: function(id, labels, datasets){
    const el = document.getElementById(id);
    if(!el){ console.warn('Line chart element not found:', id); return; }
    this._destroy(id);
    console.log('Render line', id, labels, datasets);
    this._instances[id] = new Chart(el, { type:'line', data:{ labels:labels, datasets:datasets.map(d=>({ label:d.label, data:d.data, borderColor:d.color, backgroundColor:'transparent', tension:0.4, borderWidth:3 })) }, options:{ responsive:true, maintainAspectRatio:false, plugins:{ legend:{ display:false } }, scales:{ y:{ beginAtZero:true, grid:{ display:true, color:'#F0F0F0' }, ticks:{ color:'#888' } }, x:{ grid:{ display:false }, ticks:{ color:'#888' } } } } });
  }
};