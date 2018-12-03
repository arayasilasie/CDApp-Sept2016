
function SelectAllRows(chbCheckAll)
{
    table = document.getElementById('MyTable');
    inputs = table.getElementsByTagName('input');
    
    var checkboxes = new Array();
    for (i = 0; i < inputs.length; i++)
    {
      if (!inputs[i].length)
      {
        if (inputs[i].type == 'checkbox')
          checkboxes[checkboxes.length] = inputs[i];
      } 
      else
      {
        for(k = 0; k < inputs[i].length; k++)
        {
          if (inputs[i][k].type == 'checkbox')
            checkboxes[checkboxes.length] = inputs[i];
        }
      }
    }
    
    for (i = 0; i < checkboxes.length; i++)
        checkboxes[i].checked = chbCheckAll.checked;
}


function SwitchSelectAllRows(chbCheckAll)
{
    var tableName = chbCheckAll.id.substring(0,chbCheckAll.id.length-19);
    table = document.getElementById(tableName);
    inputs = table.getElementsByTagName('input');
    
    var checkboxes = new Array();
    for (i = 0; i < inputs.length; i++)
    {
      if (!inputs[i].length)
      {
        if (inputs[i].type == 'checkbox')
          checkboxes[checkboxes.length] = inputs[i];
      } 
      else
      {
        for(k = 0; k < inputs[i].length; k++)
        {
          if (inputs[i][k].type == 'checkbox')
            checkboxes[checkboxes.length] = inputs[i];
        }
      }
    }
    
    for (i = 0; i < checkboxes.length; i++)
        checkboxes[i].checked = chbCheckAll.checked;
}