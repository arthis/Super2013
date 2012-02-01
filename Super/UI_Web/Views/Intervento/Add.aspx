<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Commands.CreareNuovoIntervento>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Add
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add</h2>

    <% using (Html.BeginForm())
       {%>
        <%: Html.ValidationSummary(true)%>

        <fieldset>
            <legend>Fields</legend>
            
            <%= Html.HiddenFor(model => model.CommandIdentifier) %>
            <%= Html.HiddenFor(model => model.Guid)%>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Inizio)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Inizio)%>
                <%: Html.ValidationMessageFor(model => model.Inizio)%>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.Fine)%>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Fine)%>
                <%: Html.ValidationMessageFor(model => model.Fine)%>
            </div>
            
            <p>
                <input type="submit" value="Creare Intervento" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%: Html.ActionLink("Back to List", "Index")%>
    </div>

</asp:Content>

