window.Alerts = {
  success: function(title, text){
    Swal.fire({icon:'success', title:title||'Éxito', text:text||'', confirmButtonColor:'#0071BE'});
  },
  error: function(title, text){
    Swal.fire({icon:'error', title:title||'Error', text:text||'', confirmButtonColor:'#0071BE'});
  },
  info: function(title, text){
    Swal.fire({icon:'info', title:title||'Información', text:text||'', confirmButtonColor:'#0071BE'});
  },
  confirm: function(title, text){
    return Swal.fire({title:title||'¿Confirmar?', text:text||'', icon:'warning', showCancelButton:true, confirmButtonColor:'#d33', cancelButtonColor:'#6E7C87', confirmButtonText:'Sí', cancelButtonText:'Cancelar'}).then(r=>r.isConfirmed);
  }
};