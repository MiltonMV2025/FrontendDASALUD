window.DashboardApex = {
  renderDoughnut: function(id, value){
    const el = document.querySelector('#'+id);
    if(!el){ console.warn('doughnut element not found', id); return; }
    const options = {
      chart: { type: 'donut', height: 250 },
      labels: ['Consultas','Resto'],
      series: [value, Math.max(value*0.3,1)],
      colors: ['#005792','#E8F4F8'],
      dataLabels: { enabled: false },
      legend: { show: false }
    };
    const chart = new ApexCharts(el, options); chart.render();
  },
  renderBar: function(id, labels, data){
    const el = document.querySelector('#'+id);
    if(!el){ console.warn('bar element not found', id); return; }
    const options = {
      chart:{ type:'bar', height:300, toolbar:{show:false}},
      series:[{ name:'Consultas', data:data}],
      xaxis:{ categories: labels },
      colors:['#005792'],
      plotOptions:{ bar:{ borderRadius:6 }},
      dataLabels:{ enabled:false },
      grid:{ strokeDashArray:4 }
    }; new ApexCharts(el, options).render();
  },
  renderLineMulti: function(id, labels, datasets){
    const el = document.querySelector('#'+id);
    if(!el){ console.warn('line element not found', id); return; }
    const series = datasets.map(d=>({ name: d.label, data: d.data }));
    const options = {
      chart:{ type:'line', height:300, toolbar:{show:false}},
      series: series,
      xaxis:{ categories: labels },
      colors: datasets.map(d=>d.color),
      stroke:{ curve:'smooth', width:3 },
      dataLabels:{ enabled:false },
      grid:{ strokeDashArray:4 }
    }; new ApexCharts(el, options).render();
  }
};